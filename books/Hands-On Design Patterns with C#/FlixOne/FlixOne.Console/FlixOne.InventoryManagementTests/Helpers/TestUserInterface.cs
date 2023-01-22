using FlixOne.InventoryManagement.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlixOne.InventoryManagementTests.Helpers
{

    public class TestUserInterface : IUserInterface
    {
        private readonly List<Tuple<string, string>> _excpectedReadRequests;
        private readonly List<string> _expectedWriteMessageRequests;
        private readonly List<string> _expectedWriteWarningRequests;

        private int _expectedWriteWarningRequestsIndex;
        private int _expectedReadRequestsIndex;
        private int _expectedWriteMessageRequestsIndex;

        public TestUserInterface(List<Tuple<string, string>> excpectedReadRequests, List<string> expectedWriteMessageRequests, List<string> expectedWriteWarningRequests)
        {
            _excpectedReadRequests = excpectedReadRequests;
            _expectedWriteMessageRequests = expectedWriteMessageRequests;
            _expectedWriteWarningRequests = expectedWriteWarningRequests;
        }

        public string ReadValue(string message)
        {
            Assert.IsTrue(
                _expectedReadRequestsIndex < _excpectedReadRequests.Count,
                "Received too many command read requests.");
            Assert.AreEqual(
                _excpectedReadRequests[_expectedReadRequestsIndex].Item1,
                message,
                "Received unexpected command read message.");
            return _excpectedReadRequests[_expectedReadRequestsIndex++].Item2;
        }

        public void WriteMessage(string message)
        {
            Assert.IsTrue(
                _expectedWriteMessageRequestsIndex < _expectedWriteMessageRequests.Count,
                "Received too many command write warning requests.");
            Assert.AreEqual(
                _expectedWriteMessageRequests[_expectedWriteMessageRequestsIndex++], message,
                "Received unexpected command write warning message.");
        }
        public void WriteWarning(string message)
        {
            Assert.IsTrue(
                _expectedWriteWarningRequestsIndex < _expectedWriteWarningRequests.Count,
                "Received too many command write warning requests.");
            Assert.AreEqual(
                _expectedWriteWarningRequests[_expectedWriteWarningRequestsIndex++], message,
                "Received unexpected command write warning message.");
        }

        public void Validate()
        {
            Assert.IsTrue(
                _expectedReadRequestsIndex == _excpectedReadRequests.Count,
                "Not all read requests were performed.");
            Assert.IsTrue(
                _expectedWriteMessageRequestsIndex == _expectedWriteMessageRequests.Count,
                "Not all write requests were performed.");
            Assert.IsTrue(
                _expectedWriteWarningRequestsIndex == _expectedWriteWarningRequests.Count,
                "Not all warning requests were performed.");
        }
    }
}
