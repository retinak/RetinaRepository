using System;
using SASSMMS.Domain.Entities;


namespace SASSMMS.Repository
{
    public class UnitOfWork :  IDisposable
    {
        private readonly MainContext mainContext = new MainContext();
       
        #region Registration Module
        private GenericRepository<Division> divisionRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Member> memberRepository;
        private GenericRepository<Subcity> subcityRepository;
        private GenericRepository<Woreda> woredaRepository;
        private GenericRepository<School> schoolRepository;
        private GenericRepository<Qualification> qualificationRepository; 
        private GenericRepository<Region> regionRepository;
        private GenericRepository<Position> positionRepository;
        private GenericRepository<Status> statusRepository;

        public GenericRepository<Status> StatusRepository
        {
            get {
                if (statusRepository == null)
                {
                    statusRepository = new GenericRepository<Status>(mainContext);
                }
                return statusRepository;
            }
        } 
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

        public GenericRepository<Position> PositionRepository
        {
            get {
                if (positionRepository == null)
                {
                    positionRepository=new GenericRepository<Position>(mainContext);
                }
                return positionRepository;
            }
        } 
        public GenericRepository<Qualification> QualificationRepository
        {
            get { if( qualificationRepository==null)
                {
                    qualificationRepository=new GenericRepository<Qualification>(mainContext);
                }
                return qualificationRepository;
            }
        } 
        public GenericRepository<School> SchoolRepository
        {
            get
            {
                if (schoolRepository == null)
                {
                    schoolRepository=new GenericRepository<School>(mainContext);
                }
                return schoolRepository;
            }
        } 
        public GenericRepository<Region> RegionRepository
        {
            get
            {
                if (regionRepository == null)
                {
                    regionRepository = new GenericRepository<Region>(mainContext);
                }
                return regionRepository;
            }
        }

        public GenericRepository<Member> MemberRepository
        {
            get { return memberRepository ?? (memberRepository = new GenericRepository<Member>(mainContext)); }
        } 
        public GenericRepository<Division> DivisionRepository
        {
            get
            {
                if (divisionRepository == null)
                {
                    divisionRepository = new GenericRepository<Division>(mainContext);
                }
                return divisionRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(mainContext);
                }
                return categoryRepository;
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
