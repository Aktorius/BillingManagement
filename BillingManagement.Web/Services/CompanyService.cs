﻿using System;
using System.Collections.Generic;
using System.Linq;
using BillingManagement.Business.Repositories;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ISiteRepository _siteRepository;
        private readonly IBillingRepository _billingRepository;

        public CompanyService() 
            : this(new CompanyRepository(),
                  new SiteRepository(),
                  new BillingRepository()) { }

        public CompanyService(ICompanyRepository companyRepository,
                              ISiteRepository siteRepository,
                              IBillingRepository billingRepository)
        {
            _companyRepository = companyRepository;
            _siteRepository = siteRepository;
            _billingRepository = billingRepository;
        }

        public Company GetCompany(int companyId)
        {
            var company = _companyRepository.FindById(companyId);

            if(company == null)
                throw new Exception("company does not exist");

            return new Company()
            {
                Id = company.CompanyId,
                Name = company.Name
            };
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = _companyRepository.GetAllCompanies().ToList();

            if(companies.Count == 0)
                return new List<Company>();

            return companies.Select(company => new Company()
            {
                Id = company.CompanyId,
                Name = company.Name
            }).ToList();
        }

        public IEnumerable<Site> GetSitesForCompany(int companyId)
        {
            var company = _companyRepository.FindById(companyId);

            if(company == null)
                throw new Exception("company does not exist");

            var sites = _siteRepository.GetSitesForCompany(company.CompanyId);

            return sites.Select(site => new Site()
            {
                Id = site.SiteId,
                Name = site.Name
            }).ToList();
        }

        public IEnumerable<Billing> GetBillingsForSite(int siteId)
        {
            var site = _siteRepository.FindById(siteId);

            if(site == null)
                throw new Exception("site does not exist");

            var billings = _billingRepository.GetBillingsForSite(site.SiteId);

            return billings.Select(billing => new Billing()
            {
                Id = billing.BillingId,
                BillingPhone = billing.BillingPhone,
                DateFrom = billing.DateFrom,
                DateTo = billing.DateTo,
                Notes = billing.Notes
            }).ToList();
        }

        public bool CreateCompany(string companyName)
        {
            if(string.IsNullOrEmpty(companyName))
                throw new Exception("Company name is empty");

            return !_companyRepository.CompanyExists(companyName) && _companyRepository.Add(new Database.Models.Company()
            {
                Name = companyName
            });
        }

        public bool EditCompany(Company company)
        {
            var companyToUpdate = _companyRepository.FindById(company.Id);

            if(companyToUpdate == null)
                throw new Exception("company dos not exist");

            if (company.Name == companyToUpdate.Name)
                return false;
            companyToUpdate.Name = company.Name;

            return _companyRepository.Update(companyToUpdate);
        }
    }
}