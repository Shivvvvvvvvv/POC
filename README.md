# Best Stories API

## Overview

Implemented a RESTful API to retrieve the details of the best stories from the Hacker News API, as determined by their score, where number of top stories is specified by the caller.

## Required Components
1. Newtonsoft.Json Package
2. Swashbuckle.AspNetCore - Swagger Package
3. Polly

## Instructions
After downloading the code from this repository, launch Visual Studio 2022, restore all of the packages, and execute the code. Users can execute and test directly from their browser because swagger is configured in the code.

Note: Because the master data is cached, the initial request may take a bit longer than anticipated. It will be quick from the second request on. Data cached for 5 mins and it will be changeable. 

Components Used
Rate Limiting:   
  To prevent overloading the Hacker News API, implemented rate limiting. Used a Polly library to implement rate limiting policies. 
  In this project, limited the request to 10 per second.

Caching:
  Used a caching mechanism to store the results of the best story IDs and story details. This can help reduce the number of requests made to the Hacker News API and improve the response time. used the MemoryCache provided by ASP.NET Core to store the results in-memory. Cached for 5 mins in this project.


### Enhancements :
1. Need to move all the hard coded values to appsetting.json like Hacker New API, Rate Limit and cache values.
2. Need to implement Exception handling.
   




