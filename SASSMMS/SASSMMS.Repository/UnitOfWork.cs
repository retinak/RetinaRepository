using System;
using SASSMMS.Domain.Entities;


namespace SASSMMS.Repository
{
    public class UnitOfWork :  IDisposable
    {
        private MainContext simsContext = new MainContext();
       
        #region Curriculum Module Repository
        private GenericRepository<Division> divisionRepository;
        private GenericRepository<Category> categoryLevelRepository;
        private GenericRepository<Member> memberRepository;
      
        private GenericRepository<Applicant> applicantRepository;
        private GenericRepository<Region> regionRepository;

        public GenericRepository<Region> RegionRepository
        {
            get
            {
                if (this.regionRepository == null)
                {
                    this.regionRepository = new GenericRepository<Region>(simsContext);
                }
                return regionRepository;
            }
        }

        public GenericRepository<Applicant> ApplicantRepository
        {
            get
            {
                if (this.applicantRepository == null)
                {
                    this.applicantRepository = new GenericRepository<Applicant>(simsContext);
                }
                return applicantRepository;
            }
        }
        public GenericRepository<Division> DivisionRepository
        {
            get
            {
                if (this.divisionRepository == null)
                {
                    this.divisionRepository = new GenericRepository<Division>(simsContext);
                }
                return divisionRepository;
            }
        }
        public GenericRepository<Category> CategoryLevelReporitory
        {
            get
            {
                if (this.categoryLevelRepository == null)
                {
                    this.categoryLevelRepository = new GenericRepository<Category>(simsContext);
                }
                return categoryLevelRepository;
            }
        }
        public GenericRepository<Member> MemberReporitory
        {
            get
            {
                if (this.memberRepository == null)
                {
                    this.memberRepository = new GenericRepository<Member>(simsContext);
                }
                return memberRepository;
            }
        }
        //public GenericRepository<Receive> ReceiveReporitory
        //{
        //    get
        //    {
        //        if (this.receiveRepository == null)
        //        {
        //            this.receiveRepository = new GenericRepository<Receive>(simsContext);
        //        }
        //        return receiveRepository;
        //    }
        //}
        //public GenericRepository<Sales> SalesReporitory
        //{
        //    get
        //    {
        //        if (this.salesRepository == null)
        //        {
        //            this.salesRepository = new GenericRepository<Sales>(simsContext);
        //        }
        //        return salesRepository;
        //    }
        //}
        //public GenericRepository<SalesDetail> SalesDetailRepository
        //{
        //    get
        //    {
        //        if (this.salesDetailRepository == null)
        //        {
        //            this.salesDetailRepository = new GenericRepository<SalesDetail>(simsContext);
        //        }
        //        return salesDetailRepository;
        //    }
        //}
        //public GenericRepository<ReceiveDetail> ReceiveDetailReporitory
        //{
        //    get
        //    {
        //        if (this.receivedDetailRepository == null)
        //        {
        //            this.receivedDetailRepository = new GenericRepository<ReceiveDetail>(simsContext);
        //        }
        //        return receivedDetailRepository;
        //    }
        //}
        //public GenericRepository<BinCard> BinCardReporitory
        //{
        //    get
        //    {
        //        if (this.bjncardRepository == null)
        //        {
        //            this.bjncardRepository = new GenericRepository<BinCard>(simsContext);
        //        }
        //        return bjncardRepository;
        //    }
        //}
        #endregion

        public bool Save()
        {
            int saveStatus = simsContext.SaveChanges();
            if (saveStatus > 0)
                return true;
            else
                return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    simsContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
