using System;
using SASSMMS.Domain.Entities;


namespace SASSMMS.Repository
{
    public class UnitOfWork :  IDisposable
    {
        private MainContext mainContext = new MainContext();
       
        #region Registration Module
        private GenericRepository<Division> divisionRepository;
        private GenericRepository<Category> categoryLevelRepository;
        private GenericRepository<Member> memberRepository;
        private GenericRepository<Subcity> subcityRepository;
        private GenericRepository<Woreda> woredaRepository; 
      
     
        private GenericRepository<Region> regionRepository;

        public GenericRepository<Woreda> WoredaRepository
        {
            get
            {
                if (woredaRepository == null)
                {
                    woredaRepository=new GenericRepository<Woreda>(mainContext);
                }
                return woredaRepository;
            }
        }

        public GenericRepository<Subcity> SubcityRepository
        {
            get
            {
                if (subcityRepository == null)
                {
                    subcityRepository=new GenericRepository<Subcity>(mainContext);
                }
                return subcityRepository;
            }
        } 

        public GenericRepository<Region> RegionRepository
        {
            get
            {
                if (this.regionRepository == null)
                {
                    this.regionRepository = new GenericRepository<Region>(mainContext);
                }
                return regionRepository;
            }
        }

        public GenericRepository<Member> MemberRepository
        {
            get
            {
                if (this.MemberRepository == null)
                {
                    this.memberRepository = new GenericRepository<Member>(mainContext);
                }
                return MemberRepository;
            }
        }
        public GenericRepository<Division> DivisionRepository
        {
            get
            {
                if (this.divisionRepository == null)
                {
                    this.divisionRepository = new GenericRepository<Division>(mainContext);
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
                    this.categoryLevelRepository = new GenericRepository<Category>(mainContext);
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
                    this.memberRepository = new GenericRepository<Member>(mainContext);
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
        //            this.receiveRepository = new GenericRepository<Receive>(mainContext);
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
        //            this.salesRepository = new GenericRepository<Sales>(mainContext);
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
        //            this.salesDetailRepository = new GenericRepository<SalesDetail>(mainContext);
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
        //            this.receivedDetailRepository = new GenericRepository<ReceiveDetail>(mainContext);
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
        //            this.bjncardRepository = new GenericRepository<BinCard>(mainContext);
        //        }
        //        return bjncardRepository;
        //    }
        //}
        #endregion

        public bool Save()
        {
            int saveStatus = mainContext.SaveChanges();
            if (saveStatus > 0)
                return true;
            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    mainContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
