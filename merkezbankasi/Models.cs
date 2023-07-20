string tcmblink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml", (request.IsBugun) ? ("today") : string.Format("{2}{1}/{0}{1}{2}"
                   , request.Gun.ToString(), request.Ay.ToString(), request.Yil));
Console.WriteLine();
