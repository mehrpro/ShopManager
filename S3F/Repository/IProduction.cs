using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPS.Entities.Product;
using SPS.Models.Context;

namespace SPS.Repository
{
    public interface IProduction
    {
        /// <summary>
        /// لیست انبار های اصلی
        /// </summary>
        /// <returns></returns>
        Task<List<IndexStoreViewModel>> GetAllIndexStore();

        /// <summary>
        /// ثبت انبار جدید
        /// </summary>
        /// <param name="indexStoreViewModel"></param>
        /// <returns></returns>
        Task<bool> CreateIndexStore(IndexStoreViewModel indexStoreViewModel);
    }

   public class Production : IProduction
   {
       private AppDbContext _context;
       private IMapper _mapper;

       public Production(AppDbContext context, IMapper mapper)
       {
           _context = context;
           _mapper = mapper;
       }

       public async Task<List<IndexStoreViewModel>> GetAllIndexStore()
       {
           var qry = await _context.IndexStores.ToListAsync();
           var listResult = new List<IndexStoreViewModel>();
           foreach (var indexStore in qry)
           {
               var item = _mapper.Map<IndexStoreViewModel>(indexStore);
               listResult.Add(item);
           }

           return listResult;
       }

       public async Task<bool> CreateIndexStore(IndexStoreViewModel indexStoreViewModel)
       {
           try
           {
               var item = _mapper.Map<IndexStore>(indexStoreViewModel);
               await _context.IndexStores.AddAsync(item);
               await _context.SaveChangesAsync();
               return true;
           }
           catch
           {
               return false;
           }
       }
   }
}