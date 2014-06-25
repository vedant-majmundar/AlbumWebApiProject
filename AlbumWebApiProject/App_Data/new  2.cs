            var albumList = (from objAlbum in albumData.Element("music").Elements("album")
                                select new Album
                                {
                                    Id = Int16.Parse(objAlbum.Element("album").Attribute("Id").Value),
                                    Title = objAlbum.Element("album").Attribute("title").Value,
                                    AlbumSongList = ( from songs in objAlbum.Element("album").Elements("song")
                                        select new Song
                                        {
                                            songId = Int16.Parse(songs.Attribute("SongId").Value),
                                            songTitle = songs.Attribute("title").Value,
                                            length = songs.Attribute("length").Value
                                        }                                   
                                    ),                                   
                                
                                })   


                                       select new Album
                                        (
                                            Int16.Parse(objAlbum.Element("album").Attribute("Id").Value),
                                            objAlbum.Element("album").Attribute("title").Value,
                                            ( from songs in objAlbum.Element("album").Elements("song")
                                                select new Song
                                                (
                                                   Int16.Parse(songs.Attribute("SongId").Value),
                                                   songs.Attribute("title").Value,
                                                   songs.Attribute("length").Value
                                                )                                   
                                            ).ToList(),                                   
                                
                                        )).ToList;   
										
										
										
										            var albumList = (from objAlbum in albumData.Element("music").Elements("album")
                                        select new Album
                                        (
                                            Int16.Parse(objAlbum.Element("album").Attribute("Id").Value),
                                            objAlbum.Element("album").Attribute("title").Value,
                                            ( from songs in objAlbum.Element("album").Elements("song")
                                                select new Song
                                                (
                                                   Int16.Parse(songs.Attribute("SongId").Value),
                                                   songs.Attribute("title").Value,
                                                   songs.Attribute("length").Value
                                                )                                   
                                            ).ToList()                                                            
                                        )).ToList();   
										
										
								          
			var albumData = XDocument.Load("C:\\EAF\\AlbumAppSample.xml");
		

            var albumList = albumData.Descendants("artist").Elements("album").Select(
                               alb => new Album
                                            {
                                                Id = alb.Attribute("Id").Value,
                                                Title = alb.Attribute("title").Value,
                                                AlbumSongList = null
												
                                            }).ToList();

			foreach(var item in albumList)
			Console.WriteLine(item);



			

public class BillingRepository: IBillingRepository
{
    private List<Billing> allBillings;
    private XDocument billingData;

    // constructor
    public BillingRepository()
    {
        allBillings = new List<Billing>();

        billingData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Billings.xml"));
        var billings = from billing in billingData.Descendants("item")
                        select new Billing((int)billing.Element("id"), billing.Element("customer").Value,
                        billing.Element("type").Value, (DateTime)billing.Element("date"),
                        billing.Element("description").Value, (int)billing.Element("hours"));
        allBillings.AddRange(billings.ToList<Billing>());
    }

    // return a list of all billings
    public IEnumerable<Billing> GetBillings()
    {
        return allBillings;
    }

    public Billing GetBillingByID(int id)
    {
        return allBillings.Find(item => item.ID == id);
    }

    // Insert Record
    public void InsertBilling(Billing billing)
    {
        billing.ID = (int)(from b in billingData.Descendants("item") orderby (int)b.Element("id") descending select (int)b.Element("id")).FirstOrDefault() + 1;

        billingData.Root.Add(new XElement("item", new XElement("id", billing.ID), new XElement("customer", billing.Customer),
            new XElement("type", billing.Type), new XElement("date", billing.Date.ToShortDateString()), new XElement("description", billing.Description),
            new XElement("hours", billing.Hours)));

        billingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Billings.xml"));
    }

    // Delete Record
    public void DeleteBilling(int id)
    {
        billingData.Root.Elements("item").Where(i => (int)i.Element("id") == id).Remove();

        billingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Billings.xml"));
    }

    // Edit Record
    public void EditBilling(Billing billing)
    {
        XElement node = billingData.Root.Elements("item").Where(i => (int)i.Element("id") == billing.ID).FirstOrDefault();

        node.SetElementValue("customer", billing.Customer);
        node.SetElementValue("type", billing.Type);
        node.SetElementValue("date", billing.Date.ToShortDateString());
        node.SetElementValue("description", billing.Description);
        node.SetElementValue("hours", billing.Hours);

        billingData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Billings.xml"));
    }
}