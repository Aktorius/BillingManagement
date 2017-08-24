using System;
using System.Collections.Generic;
using System.Linq;
using BillingManagement.Business.Repositories;
using BillingManagement.Database.Models;
using BillingManagement.Web.Services;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BillingManagement.Unit.Tests.BillingManagement.Web.Services
{
    [TestFixture]
    class CompanyServiceTests
    {
        private Mock<ICompanyRepository> _companyRepositoryMock;
        private Mock<ISiteRepository> _siteRepositoryMock;
        private Mock<IBillingRepository> _billingRepositoryMock;
        private ICompanyService _companyService;

        [SetUp]
        public void Setup()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _siteRepositoryMock = new Mock<ISiteRepository>();
            _billingRepositoryMock = new Mock<IBillingRepository>();

            _companyService = new CompanyService(_companyRepositoryMock.Object, _siteRepositoryMock.Object, _billingRepositoryMock.Object);
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

        [Test]
        public void GetSitesForCompany_Should_Return_An_List_Of_Sites()
        {
            // Given
            var company = new Company()
            {
                CompanyId = 42
            };
            var sites = new List<Site>()
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
                },
                new Site()
                {
                    SiteId = 425
                }
            };

            _companyRepositoryMock.Setup(x => x.FindById(It.IsAny<int>())).Returns(company);
            _siteRepositoryMock.Setup(x => x.GetSitesForCompany(It.IsAny<int>())).Returns(sites);

            // When
            var result = _companyService.GetSitesForCompany(42).ToList();

            // Then
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(404, result[0].Id);
            Assert.AreEqual(425, result[1].Id);
        }

        [Test]
        public void GetSitesForCompany_Should_Throw_An_Exception_When_Company_Does_Not_Exist()
        {
            //Given
            _companyRepositoryMock.Setup(x => x.FindById(It.IsAny<int>())).Returns((Company) null);
            bool success = false;

            // When
            try
            {
                _companyService.GetSitesForCompany(42);
            }
            catch (Exception e)
            {
                success = true;
            }

            // Then
            Assert.IsTrue(success);
        }

        [Test]
        public void GetBillingsForSite_Should_Return_A_List_Of_Billings()
        {
            // Given
            var site = new Site()
            {
                SiteId = 42
            };

            var billings = new List<Billing>()
            {
                new Billing()
                {
                    BillingId = 43,
                    BillingPhone = "0121",
                    DateTo = DateTime.Now,
                    DateFrom = DateTime.Now
                },
                new Billing()
                {
                    BillingId = 101,
                    BillingPhone = "0121",
                    DateTo = DateTime.Now,
                    DateFrom = DateTime.Now
                }
            };

            _siteRepositoryMock.Setup(x => x.FindById(It.IsAny<int>())).Returns(site);
            _billingRepositoryMock.Setup(x => x.GetBillingsForSite(site.SiteId)).Returns(billings);

            // When
            var results = _companyService.GetBillingsForSite(site.SiteId).ToList();

            // Then
            Assert.IsNotEmpty(results);
            Assert.AreEqual(43, results[0].Id);
            Assert.AreEqual(101, results[1].Id);
        }

        [Test]
        public void GetBillingsForSite_Should_Throw_An_Exception_If_Site_Is_Not_Found()
        {
            //Given
            _siteRepositoryMock.Setup(x => x.FindById(It.IsAny<int>())).Returns((Site)null);
            bool success = false;

            // When
            try
            {
                _companyService.GetBillingsForSite(42);
            }
            catch (Exception e)
            {
                success = true;
            }

            // Then
            Assert.IsTrue(success);
        }

        [Test]
        public void CreateCompany_Should_Throw_An_Exception_If_Model_Is_Null()
        {
            // Given
            bool success = false;

            // When
            try
            {
                _companyService.CreateCompany(null);
            }
            catch (Exception e)
            {
                success = true;
            }

            // Then
            Assert.IsTrue(success);
        }

        [Test]
        public void CreateCompany_ShouldReturn_False_When_The_Company_Exists()
        {
            // Given

            _companyRepositoryMock.Setup(x => x.CompanyExists(It.IsAny<string>())).Returns(true);

            // When
            var result = _companyService.CreateCompany("existing");

            // Then
            Assert.IsFalse(result);
        }

        [Test]
        public void CreateCompany_Should_Return_True_When_Company_Creates()
        {
            // Given
            _companyRepositoryMock.Setup(x => x.CompanyExists(It.IsAny<string>())).Returns(false);
            _companyRepositoryMock.Setup(x => x.Add(It.IsAny<Company>())).Returns(true);

            // When
            var result = _companyService.CreateCompany("company");

            // Then
            Assert.IsTrue(result);
        }
    }
}
