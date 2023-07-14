using FakeItEasy;
using FluentAssertions;
using quickformapi.expresstaxexempt.com.Controllers;
using quickformapi.expresstaxexempt.com.Core.IRepository;
using quickformapi.expresstaxexempt.com.Core.IServices;
using quickformapi.expresstaxexempt.com.Core.Model;
using quickformapi.expresstaxexempt.com.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickformapi.expresstaxexempt.com.Tests.Services
{
    public class QForm990PFServiceTest
    {
        #region Declaration
        private readonly IQForm990PFRepository _form990PFRepository;
        private readonly ICommonRepository _commonRepository;
        private readonly IQForm990PFService _form990PFService;
        #endregion


        #region Constructor
        public QForm990PFServiceTest()
        {
            _form990PFRepository = A.Fake<IQForm990PFRepository>();
            _commonRepository = A.Fake<ICommonRepository>();
            _form990PFService = new QForm990PFService(_form990PFRepository, _commonRepository);
        }
        #endregion

        #region Sample
        [Fact]
        public void Sample()
        {


            Console.WriteLine("Check");
        }
        #endregion

        #region Test - Get QForm990PF Part13 Details by ReturnId
        [Fact]
        public void QForm990PFController_GetQForm990PFPart13Details_returnsQFForm990PFPart13()
        {
            //Arrange
            long returnId = 295941;

            #region Fake Model to Return
            var fakePart13toReturn = new QFForm990PFPart13();
            fakePart13toReturn.Part13Line2A = 10;
            fakePart13toReturn.Part13Line2B = 20;
            fakePart13toReturn.Part13Line3A = 1;
            fakePart13toReturn.Part13Line3B = 2;
            fakePart13toReturn.Part13Line3C = 3;
            fakePart13toReturn.Part13Line3D = 4;
            fakePart13toReturn.Part13Line3E = 5;
            fakePart13toReturn.Part13Line4A = 5;
            
            var fakePart12 = new QFForm990PFPart12();

            var fakepage1Details = new QForm990PFPage1();
            fakepage1Details.PFHeaderDetails = new QForm990PFHeader();
            fakepage1Details.PFHeaderDetails.TaxYear = "2022";
            #endregion

            #region Value to Expect after calculation

            var exceptedPart13 = new QFForm990PFPart13();
            exceptedPart13.Part13Line1 = 0;
            exceptedPart13.Part13Line2A = 10;
            exceptedPart13.Part13Line2B = 20;
            exceptedPart13.Part13Line3A = 1;
            exceptedPart13.Part13Line3B = 2;
            exceptedPart13.Part13Line3C = 3;
            exceptedPart13.Part13Line3D = 4;
            exceptedPart13.Part13Line3E = 5;
            exceptedPart13.Part13Line4A = 5;
            exceptedPart13.Part13Line4 = 0;
            exceptedPart13.Part13Line3f = 15;
            exceptedPart13.Part13Line6A = 15;
            exceptedPart13.Part13Line6B = 20;
            exceptedPart13.Part13Line6D = 20;
            exceptedPart13.Part13Line6E = 5;
            exceptedPart13.Part13Line6F = 0;
            exceptedPart13.Part13Line9 = 15;
            exceptedPart13.IsPrivateOrForeignOrganization = false;

            #endregion

            A.CallTo(() => _form990PFRepository.GetQForm990PFPart13Details(returnId)).Returns(fakePart13toReturn);
            A.CallTo(() => _form990PFRepository.GetQFForm990PFPart12Details(returnId)).Returns(fakePart12);
            A.CallTo(() => _commonRepository.GetQForm990PFPage1Details(returnId)).Returns(fakepage1Details);

            //Act
            var result = _form990PFService.GetQForm990PFPart13Details(returnId);

            //Assert
            result.Should().NotBeNull();
            result.Part13Line3f.Should().Be(25);
            result.Part13Line4A.Should().BeLessThanOrEqualTo(result.Part13Line2A ?? 0);
            result.Part13Line6B.Should().Be(20);
            result.Part13Line9.Should().Be(15);

            result.Should().BeEquivalentTo(exceptedPart13);

        }
        #endregion
    }
}
