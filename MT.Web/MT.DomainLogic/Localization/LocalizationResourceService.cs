﻿using System.Collections.Generic;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;
using MT.Utility;

namespace MT.DomainLogic.Localization
{
    public class LocalizationResourceService : ILocalizationResourceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocalizationResourceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(LocalizationResource libraryResource)
        {
            _unitOfWork.Add(libraryResource);
        }

        public int SafeAddUniqueEntry(IEnumerable<LocalizationResource> resources)
        {
            int itemsAddedToDb = 0;
            foreach (var resource in resources)
            {
                var isPresent = _unitOfWork.Get<LocalizationResource>().Any(entry => ((entry.ResourceKey == resource.ResourceKey)
                                                                             &&
                                                                             (entry.ResourceCultureCode == resource.ResourceCultureCode)));
                if (!isPresent)
                {
                    _unitOfWork.Add(resource);
                    itemsAddedToDb++;
                }
            }

            return itemsAddedToDb;
        }


    }
}