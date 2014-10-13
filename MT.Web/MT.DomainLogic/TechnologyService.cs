using System.Collections.Generic;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public class TechnologyService : ITechnologyService
    {
        private IUnitOfWork _unitOfWork;

        public TechnologyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Technology> Find(string query)
        {
            return _unitOfWork.Get<Technology>().Where(t => t.Name.Contains(query));
        }
    }
}
