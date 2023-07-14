using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using quickformapi.expresstaxexempt.com.Controllers;
using quickformapi.expresstaxexempt.com.Core.IServices;
using quickformapi.expresstaxexempt.com.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickformapi.expresstaxexempt.com.Tests.Controller
{
    public class QForm990PFControllerTest
    {
        #region Declaration
        private readonly ICommonService _commonService;
        private readonly IQFFormPDFGenerationService _pdfGenerationService;
        private readonly IQForm990PFService _form990PFService;
        private readonly IConfiguration _config;

        #endregion

        #region Constructor
        public QForm990PFControllerTest()
        {
            //ICommonService commonService, IConfiguration config, IQFFormPDFGenerationService pdfGenerationService, IQForm990PFService form990PFService
            _commonService = A.Fake<ICommonService>();
            _pdfGenerationService =  A.Fake<IQFFormPDFGenerationService>();
            _form990PFService =  A.Fake<IQForm990PFService>();
            _config = A.Fake<IConfiguration>();

        }
        #endregion

        #region Sample
         [Fact]
        public void Sample()
        {
            //Arrange
            long part1L6Id = 98;
            long returnId = 295911;
            
            var excepted = new QFForm990PFPart1Line6Details();
            excepted.ReturnId = returnId;
            excepted.Part1Line6SpecificId = part1L6Id;
            excepted.SaleOfAssetsName = "test1";
            excepted.DateObtained = DateTime.Now.AddDays(-28);
            excepted.DateSold = DateTime.Now.AddDays(-27);
            excepted.CostOrOtherBasis = 100;
            excepted.Expenses = 200;
            excepted.CostOrOtherBasis = 100;
            excepted.CostOrOtherBasis = 100;
            excepted.IsDepreciableProperty = true;

            var pfCon = new QForm990PFController(_commonService,_config,_pdfGenerationService,_form990PFService);
            A.CallTo(() => _form990PFService.GetPart1Line6SpecificDetailsById(part1L6Id,returnId)).Returns(excepted);

            //Act
            var result = pfCon.GetPart1Line6SpecificDetailsById(98, 295911);

            Console.WriteLine("Check");
        }
        #endregion

        #region Test - Get Part1 Line6 Specific Details By PrimaryId
        [Fact]
        public void QForm990PFController_GetPart1Line6SpecificDetailsById_returnsQFForm990PFPart1Line6Details()
        {
            //Arrange
            long part1L6Id = 98;
            long returnId = 295911;

            var excepted = new QFForm990PFPart1Line6Details();
            excepted.ReturnId = returnId;
            excepted.Part1Line6SpecificId = part1L6Id;
            excepted.SaleOfAssetsName = "test1";
            excepted.DateObtained = DateTime.Now.AddDays(-28);
            excepted.DateSold = DateTime.Now.AddDays(-27);
            excepted.CostOrOtherBasis = 100;
            excepted.Expenses = 200;
            excepted.IsDepreciableProperty = true;
            
            var fakeModelToRetuirn = new QFForm990PFPart1Line6Details();
            fakeModelToRetuirn.ReturnId = returnId;
            fakeModelToRetuirn.Part1Line6SpecificId = part1L6Id;
            fakeModelToRetuirn.SaleOfAssetsName = "test1";
            fakeModelToRetuirn.DateObtained = DateTime.Now.AddDays(-28);
            fakeModelToRetuirn.DateSold = DateTime.Now.AddDays(-27);
            fakeModelToRetuirn.CostOrOtherBasis = 100;
            fakeModelToRetuirn.Expenses = 200;
            fakeModelToRetuirn.IsDepreciableProperty = true;
            
            var _qForm990PFController = new QForm990PFController(_commonService,_config,_pdfGenerationService,_form990PFService);
            A.CallTo(() => _form990PFService.GetPart1Line6SpecificDetailsById(part1L6Id,returnId)).Returns(fakeModelToRetuirn);

            //Act
            var result = _qForm990PFController.GetPart1Line6SpecificDetailsById(part1L6Id, returnId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<QFForm990PFPart1Line6Details>();
        //    result.SaleOfAssetsName.Should().Be("test");
            result.ReturnId.Should().Be(returnId);
            result.Part1Line6SpecificId.Should().Be(part1L6Id);
            result.SaleOfAssetsName.Should().NotBeNullOrWhiteSpace();
            result.Should().BeEquivalentTo(excepted);
        }
        #endregion

        #region Test - Delete Part1Line6 SpecificDetailsById
        [Fact]
        public void QForm990PFController_DeletePart1Line6SpecificDetailsById_returnsbool()
        {
            //Arrange
            long part1L6Id = 12345;
            long returnId = 98765;

            var _qForm990PFController = new QForm990PFController(_commonService,_config,_pdfGenerationService,_form990PFService);
            A.CallTo(() => _form990PFService.DeletePart1Line6SpecificDetailsById(part1L6Id,returnId)).Returns(true);

            //Act
            var result = _qForm990PFController.DeletePart1Line6SpecificDetailsById(part1L6Id, returnId);

            //Assert
            result.Should().BeTrue();
        }
        #endregion

        #region Test - Save All QF Form990PF Part7Line12 Specific
        [Fact]
        public void QForm990PFController_SaveAllQFForm990PFPart7Line12Specific_returnsQFForm990PFPart1Line6Details()
        {
            //Arrange
            var toSave = new QFForm990PFPart7Line12Specific();
            toSave.ReturnId = 12345;
            toSave.PFPart7Line12SpecificDetails = new List<QFForm990PFPart7Line12SpecificDetail>();
            
            var _qForm990PFController = new QForm990PFController(_commonService,_config,_pdfGenerationService,_form990PFService);
            A.CallTo(() => _form990PFService.SaveAllQFForm990PFPart7Line12Specific(toSave)).Returns(true);
            //Act
            var result = _qForm990PFController.SaveAllQFForm990PFPart7Line12Specific(toSave);

            //Assert
            result.Should().BeFalse();
        }
        #endregion

    }
}
