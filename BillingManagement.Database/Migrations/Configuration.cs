using System;
using System.Collections.ObjectModel;
using BillingManagement.Database.Models;

namespace BillingManagement.Database.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BillingManagement.Database.DataAccess.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataAccess.DatabaseContext context)
        {
            var company1 = new Company()
            {
                Name = "Example Company 1",
                Sites = new Collection<Site>()
                {
                    new Site()
                    {
                        Name = "Richmond",
                        MainSite = true,

                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                Notes = "Access to this site is restricted to company working hours",
                                BillingPhone = "0121 2254 3698",
                                DateFrom = new DateTime(2016, 3, 1),
                                DateTo = new DateTime(2017, 3, 1)
                            },
                            new Billing()
                            {
                                Notes = "Access to this site is restricted to company working hours",
                                BillingPhone = "0121 2560 2569",
                                DateFrom = new DateTime(2017, 6, 15),
                                DateTo = new DateTime(2017, 6, 15)
                            },
                            new Billing()
                            {
                                Notes = "Access to this site is restricted to company working hours",
                                BillingPhone = "0121 5896 5896",
                                DateFrom = new DateTime(2015, 9, 3),
                                DateTo = new DateTime(2015, 9, 3)
                            },
                        }
                    },
                    new Site()
                    {
                        Name = "Twickenham",
                        MainSite = false,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                Notes = "",
                                BillingPhone = "0121 5478 5689",
                                DateFrom = new DateTime(2017, 7, 8),
                                DateTo = new DateTime(2018, 7, 8)
                            }
                        }
                    }
                }
            };

            var company2 = new Company()
            {
                Name = "Example Company 2",
                Sites = new Collection<Site>()
                {
                    new Site()
                    {
                        Name = "Kingston",
                        MainSite = true,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                BillingPhone = "0208 1324 5879",
                                DateFrom = new DateTime(2016, 8, 5),
                                DateTo = new DateTime(207, 8, 5)
                            }
                        }
                    }
                }
            };

            var company3 = new Company()
            {
                Name = "Example Company 3",
                Sites = new Collection<Site>()
                {
                    new Site()
                    {
                        Name = "Kew",
                        MainSite = false,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                BillingPhone = "0208 2458 8989",
                                Notes = "24 hour access available",
                                DateFrom = new DateTime(2016, 12, 12),
                                DateTo = new DateTime(2017, 12, 12)
                            },
                            new Billing()
                            {
                                BillingPhone = "0208 2458 8965",
                                Notes = "24 hour access available",
                                DateFrom = new DateTime(2017, 8, 18),
                                DateTo = new DateTime(2018, 8, 18)
                            }
                        }
                    },
                    new Site()
                    {
                        Name = "Chiswick",
                        MainSite = true,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                BillingPhone = "0121 4578 2563",
                                DateFrom = new DateTime(2017, 6, 3),
                                DateTo = new DateTime(2018, 6, 3)
                            }
                        }
                    }
                }
            };

            var company4 = new Company()
            {
                Name = "Example Company 4",
                Sites = new Collection<Site>()
                {
                    new Site()
                    {
                        Name = "Brentford",
                        MainSite = true,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                BillingPhone = "0208 5689 2458",
                                Notes = "Beware of the dog!",
                                DateFrom = new DateTime(2017, 2, 2),
                                DateTo = new DateTime(2018, 2, 2)
                            }
                        }
                    },
                    new Site()
                    {
                        Name = "Birmingham",
                        MainSite = false,
                        Billings = new Collection<Billing>()
                        {
                            new Billing()
                            {
                                BillingPhone = "0121 2568 2352",
                                DateFrom = new DateTime(2014, 3, 1),
                                DateTo = new DateTime(2016, 3, 1)
                            }
                        }
                    }
                }
            };

            context.Companies.Add(company1);
            context.Companies.Add(company2);
            context.Companies.Add(company3);
            context.Companies.Add(company4);
            context.SaveChanges();
        }
    }
}
