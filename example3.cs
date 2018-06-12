// get customer from dbase \\

public bool get_customer_by_name(string name)
{
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format(@"http://projectexecution.nl/MY_API/?action=get_customer&name={0}", name));
    request.ContentType = "application /json";
    request.Method = "GET";


    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        if (response.StatusCode != HttpStatusCode.OK)
            Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {

            var content = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.Out.WriteLine("Response contained empty body...");
            }
            else
            {
                if (content.ToString().Contains("id"))
                {
                    Success = true;
                    Admin = 0;
                    dynamic json = JObject.Parse(content);
                    customer_id = json.id;
                    own_name = json.name;
                    company_name = json.company_name;
                    customer_address = json.address;
                    customer_postal = json.postal;
                    customer_city = json.city;
                    phone_office = json.phone_office;
                    phone_mobile = json.phone_mobile;
                    customer_createdate = json.createdate;
                }
                else
                {
                    Success = false;
                    jsonReturn = content;
                    Console.Out.WriteLine("Response: niet ingelogd!");
                }
            }
            //Assert.NotNull(content);
        }
    }
    return Success;
}

// insert appointment to dbase

public static string GetLast(this string source, int tail_length)
{
    if (tail_length >= source.Length)
        return source;
    return source.Substring(source.Length - tail_length);
}

public static string GetFirst(this string source, int tail_length)
{
    if (tail_length >= source.Length)
        return source;
    return source.Substring(0, Math.Min(tail_length, source.Length));
}
        
public bool insert_appointment(string name, string title, DateTimePicker date, DateTimePicker time, string description, DateTimePicker duration, string location, string ownname, string customername, int prive)
{
    DateTime dt;
    string datum = Convert.ToString(date);    
    string datumpie = datum.GetLast(18);

    string tijd = Convert.ToString(time);
    string tijdje = tijd.GetLast(8);

    string duur = Convert.ToString(duration);
    string duur1 = duur.GetLast(8);

    dt = Convert.ToDateTime(datumpie);
    string formattedDate = dt.ToString("yyyy-MM-dd") + " " + tijdje;

    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format(@"http://projectexecution.nl/MY_API/?action=insert_appointment&name={0}&title={1}&date={2}&&description={3}&duration={4}&location={5}&ownname={6}&customername={7}&private={8}", name, title, formattedDate, description, duur1, location, ownname, customername, prive));
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";


    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
        if (response.StatusCode != HttpStatusCode.OK)
            Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {

            var content = reader.ReadToEnd();
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.Out.WriteLine("Response contained empty body...");
            }
            else
            {
                if (content.ToString().Contains("gelukt"))
                {
                    //SetContentView(Resource.Layout.Agenda);
                    Console.WriteLine("Response: gelukt");
                }
                else
                {
                    Console.Out.WriteLine("Response: niet gelukt");
                }
            }
            //Assert.NotNull(content);
        }
    }
    return Success;
}
