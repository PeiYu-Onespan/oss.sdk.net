using NUnit.Framework;
using System;
using OneSpanSign.API;
using OneSpanSign.Sdk;
using OneSpanSign.Sdk.src.Internal.Conversion;

namespace SDK.Tests
{
    [TestFixture()]
    public class RequirementStatusConverterTest
    {
        private OneSpanSign.Sdk.RequirementStatus sdkRequirementStatus1;
        private string apiRequirementStatus1;

        [Test]
        public void ConvertAPIINCOMPLETEoINCOMPLETERequirementStatus()
        {
            apiRequirementStatus1 = "INCOMPLETE";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIREJECTEDToREJECTEDRequirementStatus()
        {
            apiRequirementStatus1 = "REJECTED";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPICOMPLETEToCOMPLETERequirementStatus()
        {
            apiRequirementStatus1 = "COMPLETE";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, sdkRequirementStatus1.getApiValue());
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedRequirementStatus()
        {
            apiRequirementStatus1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            sdkRequirementStatus1 = new RequirementStatusConverter(apiRequirementStatus1).ToSDKRequirementStatus();

            Assert.AreEqual(sdkRequirementStatus1.getApiValue(), apiRequirementStatus1);
        }

        [Test]
        public void ConvertSDKINCOMPLETEToAPIINCOMPLETE()
        {
            sdkRequirementStatus1 = OneSpanSign.Sdk.RequirementStatus.INCOMPLETE;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("INCOMPLETE", apiRequirementStatus1);
        }

        [Test]
        public void ConvertSDKREJECTEDToAPIREJECTED()
        {
            sdkRequirementStatus1 = OneSpanSign.Sdk.RequirementStatus.REJECTED;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("REJECTED", apiRequirementStatus1);
        }

        [Test]
        public void ConvertSDKCOMPLETEToAPICOMPLETE()
        {
            sdkRequirementStatus1 = OneSpanSign.Sdk.RequirementStatus.COMPLETE;
            apiRequirementStatus1 = new RequirementStatusConverter(sdkRequirementStatus1).ToAPIRequirementStatus();

            Assert.AreEqual("COMPLETE", apiRequirementStatus1);
        }

        [Test]
        public void ConvertSDKUnrecognizedRequirementStatusToAPIUnknownValue()
        {
            apiRequirementStatus1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            RequirementStatus unrecognizedRequirementStatus = RequirementStatus.valueOf(apiRequirementStatus1);
            string acutalApiValue = new RequirementStatusConverter(unrecognizedRequirementStatus).ToAPIRequirementStatus();

            Assert.AreEqual(apiRequirementStatus1, acutalApiValue);
        }

    }
}

