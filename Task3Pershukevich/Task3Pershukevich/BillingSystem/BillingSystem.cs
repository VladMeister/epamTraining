using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Pershukevich.ATS;

namespace Task3Pershukevich.billingSystem
{
    public class BillingSystem : IBillingSystem
    {
        private IList<CallInfo> _callDataList;

        public BillingSystem()
        {
            _callDataList = new List<CallInfo>();
        }

        public void AddCallData(object sender, CallInfoArgs infoArgs)
        {
            CallInfo callInfo = new CallInfo(infoArgs.CallType, infoArgs.CallingFromNumber, infoArgs.CallingToNumber);

            _callDataList.Add(callInfo);
        }

        public void AddAfterCallInfo(object sender, CallInfoArgs infoArgs)
        {
            for (int i = 0; i < _callDataList.Count; i++)
            {
                if(_callDataList[i].StartCallDate.Day == DateTime.Now.Date.Day && 
                    _callDataList[i].CallingToNumber == infoArgs.CallingToNumber && 
                    _callDataList[i].CallingFromNumber == infoArgs.CallingFromNumber)
                {
                    _callDataList[i].EndCallDate = DateTime.Now;
                    _callDataList[i].CallLength = (_callDataList[i].EndCallDate.Second - _callDataList[i].StartCallDate.Second);

                    if (_callDataList[i].CallType == CallType.Incoming)
                    {
                        _callDataList[i].Cost = 0;
                    }
                    else
                    {
                        _callDataList[i].Cost = Tariff.ChargePerSecond * _callDataList[i].CallLength;
                    }
                }
            }
        }

        public IEnumerable GetAllElements()
        {
            return _callDataList;
        }

        public IEnumerable GetLengthOfEveryCall()
        {
            return _callDataList.Select(x => x.CallLength);
        }

        public IEnumerable GetCostOfEveryCall()
        {
            return _callDataList.Select(x => x.Cost);
        }

        public IEnumerable GetDestinationNumberOfEveryCall()
        {
            return _callDataList.Select(x => x.CallingToNumber);
        }

        public IEnumerable GetFilteredCallsByDateOfCall()
        {
            return _callDataList.OrderBy(x => x.StartCallDate);
        }

        public IEnumerable GetFilteredCallsByPrice()
        {
            return _callDataList.OrderBy(x => x.Cost);
        }

        public IEnumerable GetFilteredCallsByDestinationNumber()
        {
            return _callDataList.OrderBy(x => x.CallingToNumber);
        }
    }
}
