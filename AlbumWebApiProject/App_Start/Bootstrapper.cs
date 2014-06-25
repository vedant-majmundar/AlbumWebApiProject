using Microsoft.Practices.Unity;
using AlbumWebApiProject.Models;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;

namespace AlbumWebApiProject
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //Register the repository
            container.RegisterType<IAlbumRepository, XmlalbumRepository>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}