﻿using Microsoft.EntityFrameworkCore;
using mute_mate.Server.Models;
using MuteMate.Server.Data;
using MuteMate.Server.Models;

namespace mute_mate.Server.Data.Repo
{
    public class QuoteRepo
    {

        private readonly MuteMateDbContext context;

        public QuoteRepo(MuteMateDbContext context)
        {
            this.context = context;
        }

        public async Task <List<QuoteModel>> GetCategoryPraise()
        {
            return await context.Quotes.Where(q => q.Category == "Praise").ToListAsync();
        }

        public async Task<List<QuoteModel>> GetCategoryEncouragement()
        {
            return await context.Quotes.Where(q => q.Category == "Encouragement").ToListAsync();

        }

        public async Task <QuoteModel> GetRandomPraiseQuote()
        {
            var praiseQuote = await context.Quotes.Where(q => q.Category == "Praise").ToListAsync();
     
            if(praiseQuote.Count == 0)
            {
                return null;
            }
            else
            {
                var randomQuoteIndex = new Random().Next(praiseQuote.Count);

                return praiseQuote[randomQuoteIndex];
            }

        }
        public async Task<QuoteModel> GetRandomEncouragementQuote()
        {
            var encouragementQuote = await context.Quotes.Where(q => q.Category == "Encouragement").ToListAsync();

            if(encouragementQuote.Count == 0)
            {
                return null;
            }
            else
            {
                var randomQuote = new Random().Next(encouragementQuote.Count);

                return encouragementQuote[randomQuote];
            }
        }

    }
}
