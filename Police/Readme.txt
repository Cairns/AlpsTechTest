Information on design and coding decision's that may not appear obvious or as comments in the source code.

Solution
The solution comprises the following
Some common shared libraries to function across multiple client applications
Shared PoliceAPI application to service the WPF desktop and React Web Clients
WPF desktop client application
React web client Application

NeighbourhoodBoundaryCoordinates
Used the approach of making this an IEquatable<T> and overrode the ToString() method to function with the distinct linq method.
This is because the PoliceAPI that takes a neighbourhood poly only requires information to two significant digits and the majority of the latitude and longitude of the coordinates are identical when formatted this way.
Another approach would be to use IEqualityComparer to perform the same task, however this was attempted to and would not work initially, so scrapped in favor of the above.

PoliceApiServiceTests
In an ideal world, we would capture live data from the police api and use this to generate a mock for testing the api.  This would provide the benefit of still functioning if the real police api was to ever go down so test's would not fail.