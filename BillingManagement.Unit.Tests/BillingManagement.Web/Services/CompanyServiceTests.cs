using System.Collections.Generic;
using System.Linq;
using BillingManagement.Business.Repositories;
using BillingManagement.Database.Models;
using BillingManagement.Web.Services;
using Moq;
using NUnit.Framework;

namespace BillingManagement.Unit.Tests.BillingManagement.Web.Services
{
    [TestFixture]
    class CompanyServiceTests
    {
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private ICompanyService _companyService;

        [SetUp]
        public void Setup()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();

            _companyService = new CompanyService(_companyRepositoryMock.Object);
        }

        [Test]
        public void GetAllCompanies_Should_Return_And_Empty_List_When_There_Is_No_Company()
        {
            // Given
            _companyRepositoryMock.Setup(x => x.GetAllCompanies()).Returns(new List<Company>());

            // When
            var result = _companyService.GetAllCompanies();

            // Then
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetAllCompanies_Should_Return_A_List_Of_Companies()
        {
            // Given
            var companies = new List<Company>()
            {
                new Company()
                {
                    CompanyId = 42,
                    Name = "Chuck Norris Corp",
                    Sites = new List<Site>()
                    {
                        new Site()
                        {
                            SiteId = 404,
                            CompanyKey = 42,
                            Name = "The Universe",
                            Billings = new List<Billing>()
                            {
                                new Billing()
                                {
                                    BillingId = 101,
                                    SiteKey = 404
                                }
                            }
                        }
                    }
                },
                new Company()
                {
                    CompanyId = 222,
                    Name = "Empty one",
                    Sites = new List<Site>()
                }
            };
            _companyRepositoryMock.Setup(x => x.GetAllCompanies()).Returns(companies);

            // When
            var result = _companyService.GetAllCompanies().ToList();

            // Then
            Assert.IsNotEmpty(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(42, result[0].Id);
            Assert.AreEqual(222, result[1].Id);
        }
    }
}
