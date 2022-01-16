using IndoorNavigation.Domain.Entities;

namespace IndoorNavigation.Api
{
    public static class MockRepository
    {
        public static  List<TestUser>GetAllUser()
        {
            var userList = new List<TestUser>()
            { new TestUser(){Id=new Guid("c0b5b9a3-4eda-41e4-8bb2-f2ce55be2828"),UserName="testuser1", Password="password",Token="343r43r346546546434r344r6543464r63446r4634r"},
              new TestUser(){Id=new Guid("ec49e1d7-6c32-4778-845b-0c60878d8377"),UserName="testuser2", Password="password",Token="343r43r346546546434r344r6543464asdadsr4634r"},
              new TestUser(){Id=new Guid("de1ebe70-234e-42e1-a3e2-d63e76214b0e"),UserName="testuser3", Password="password",Token="343r43r346546546434r344r6543asd464r63446r4r"},
              new TestUser(){Id=new Guid("401714e4-f0ce-4d0d-bd64-5538d9962e32"),UserName="testuser4", Password="password",Token="343r43r34asdasda6546546434r344r6543464r6344"},

            };

            return userList;

        }

        public static  List<Site> GetAllSites()
        {
            var markerList1 = new List<MapMarker>()
            { new MapMarker() { Id = new Guid(), MarkerName = "building 1", SiteId =  new Guid("401714e4-f0ce-4d0d-bd64-5538d9962e32"), BlobUrl = "" },
              new MapMarker(){Id=new Guid(),MarkerName="building 2", SiteId= new Guid("401714e4-f0ce-4d0d-bd64-5538d9962e32"),BlobUrl=""},
            };

            var marker = new MapMarker() { Id = new Guid(), MarkerName = "building 2", SiteId = new Guid("4978a3ee-ba14-4434-99e3-31a4691e578a"), BlobUrl = "" };

            var markerList2 = new List<MapMarker>()
            { new MapMarker() { Id = new Guid(), MarkerName = "building 133", SiteId =  new Guid("43dade1d-7e1f-45b7-aa5f-f779a4b9f88a"), BlobUrl = "" },
              new MapMarker(){Id=new Guid(),MarkerName="building 33", SiteId=new Guid("43dade1d-7e1f-45b7-aa5f-f779a4b9f88a"),BlobUrl=""},
               new MapMarker(){Id=new Guid(),MarkerName="building 33", SiteId=new Guid("43dade1d-7e1f-45b7-aa5f-f779a4b9f88a"),BlobUrl=""},
            };


            var markerList3 = new List<MapMarker>()
            { new MapMarker() { Id = new Guid(), MarkerName = "building 133", SiteId = new Guid("167d810e-e12d-492c-967a-1c722b73b238"), BlobUrl = "" },
              new MapMarker(){Id=new Guid(),MarkerName="building 33", SiteId=new Guid("167d810e-e12d-492c-967a-1c722b73b238"),BlobUrl=""},
               new MapMarker(){Id=new Guid(),MarkerName="building 33", SiteId=new Guid("167d810e-e12d-492c-967a-1c722b73b238"),BlobUrl=""},
            };


            var site1 = new Site() { Id = new Guid("401714e4-f0ce-4d0d-bd64-5538d9962e32"), SiteName = "TestSite1", AdminId = new Guid("c0b5b9a3-4eda-41e4-8bb2-f2ce55be2828"), MapMarkers = markerList1 };
            var site2 = new Site() { Id = new Guid("43dade1d-7e1f-45b7-aa5f-f779a4b9f88a"), SiteName = "TestSite2", AdminId = new Guid("c0b5b9a3-4eda-41e4-8bb2-f2ce55be2828"), MapMarkers = markerList2 };
            var site3 = new Site() { Id = new Guid("4978a3ee-ba14-4434-99e3-31a4691e578a"), SiteName = "TestSite3", AdminId = new Guid("de1ebe70-234e-42e1-a3e2-d63e76214b0e"), MapMarkers = new List<MapMarker>() { marker } };
            var site4 = new Site() { Id = new Guid("167d810e-e12d-492c-967a-1c722b73b238"), SiteName = "TestSite4", AdminId = new Guid("401714e4-f0ce-4d0d-bd64-5538d9962e32"), MapMarkers = markerList3 };
            var siteList = new List<Site>()
            {
              site1,site2,site3,site4   

            };

            return siteList;
        }


    }



    public class TestUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }

    }


  




}
