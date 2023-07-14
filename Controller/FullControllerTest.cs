using FakeItEasy;
using quickformapi.expresstaxexempt.com.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickformapi.expresstaxexempt.com.Tests.Controller
{
    public class FullControllerTest
    {
        #region Declaration

        QForm990PFControllerTest qForm990PFControllerTest = new QForm990PFControllerTest();

        #endregion

        #region Constructor
        public FullControllerTest()
        {

        }
        #endregion

        #region Test All Unit Test Methods in QF-PF Controller 
        [Fact]
        public void QForm990PFController_TestAllMethods_F990PF()
        {
            //Call All TestMethods in F990PF Controller to check in SingleMethod
            qForm990PFControllerTest.QForm990PFController_DeletePart1Line6SpecificDetailsById_returnsbool();
            qForm990PFControllerTest.QForm990PFController_SaveAllQFForm990PFPart7Line12Specific_returnsQFForm990PFPart1Line6Details();
            qForm990PFControllerTest.QForm990PFController_GetPart1Line6SpecificDetailsById_returnsQFForm990PFPart1Line6Details();

        }
        #endregion
    }
}
