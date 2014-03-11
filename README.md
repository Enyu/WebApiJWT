JwtAuthForWebAPI
===================

This solution includes basic implementation of JWT for WebApi.

The JwtAuthForWebAPI Provides easy implementation for JWT-based HTTP authentication in an ASP.NET Web API project.


## Start...:

### 1.Install JwtAuthForWebAPI in package Manager Console.
   ```
   Install-Package JwtAuthForWebAPI
   ```

### 2.Generate a jwt handler

    public static JwtAuthenticationMessageHandler GenerateJwtHandler()
    {
        var builder = new SecurityTokenBuilder();
        return new JwtAuthenticationMessageHandler
        {
            AllowedAudience = "http://www.enyu.com",
            AllowedAudiences = new[] { "http://www.enyuyu.com" },
            Issuer = "DMN",
            SigningToken = builder.CreateFromCertificate("your key"),
        };
    }

### 3.Register jwt handler in global configuration MessageHandlers when application start.

    protected void Application_Start()
    {
        //...
        GlobalConfiguration.Configuration.MessageHandlers.Add(JwtHandlerGenerator.GenerateJwtHandler());
    }

### 4.Add Authorize attribute in controller.

    [Authorize]
    public HttpResponseMessage Get()
    {
        //...
    }

### 5.Since the jwt use the X.509-based digital signatures, we have to run the blow commands in VS Developer Command Prompt.

   ```
    makecert -r -n "CN=your key" -sky signature -ss My -sr localmachine
    certmgr /add /c /n "your key" /s /r localmachine My /s /r localmachine root
   ```

