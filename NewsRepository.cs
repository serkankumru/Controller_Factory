using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepository:BaseRepository<NewsT>, INewsRepository
    {
        public int NewsStatus(int id)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == id);
            news.Status = !news.Status;
            ctx.SaveChanges();
            if(Convert.ToBoolean(news.Status))
                return 1;
            return 0;
        }

        public override void Update(NewsT entity)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == entity.Id);

            news.Title = entity.Title;
            news.Spot = entity.Spot;
            news.CatId = entity.CatId;
            news.Content = entity.Content;
            news.ImagesId = entity.ImagesId;

            ctx.SaveChanges();

            //base.Update(entity);
        }


        public void ReadCount(int id)
        {
            var ctx = new NewsEntities();
            NewsT news = ctx.NewsT.FirstOrDefault(x => x.Id == id);
            if (news.ReadCount == null)
                news.ReadCount = 1;
            else
                news.ReadCount++;

            ctx.SaveChanges();
        }
    }

    public class NewsRepositoryMock :  INewsRepository
    {
        static List<NewsT> listNews;
        public NewsRepositoryMock()
        {
            if (listNews == null || listNews.Count > 0)
            {
                listNews = new List<NewsT>();
                listNews.Add(new NewsT() { Id = 1, Title = "title", CatId = 1, Spot = "spot", Status = true, EditorId = 1 });
            }
        }

        public List<NewsT> List()
        {
            return listNews;
        }
        public void Add(NewsT entity)
        {
            entity.Id = listNews.Max(x => x.Id) + 1;
            listNews.Add(entity);
        }

        public void Update(NewsT entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new NotImplementedException();
        }

        public NewsT FindById(int EntityId)
        {
            throw new NotImplementedException();
        }
    }

}
