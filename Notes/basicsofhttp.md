# HTTP

"Resource Oriented Architecture"

What a resource: An important thingy your customer cares about.

Resources are identified through a URI (Uniform Resource Identitifier).

Some resources have multiple URIs


employees/bob-smith

employee-of-the-month


Representation:

Resources can be retrieved as a representation in a particular format (media type) at a POINT IN TIME.

Super honest about the representation being a projection of the "thingy".

GET /employees/sue-miller
Accept: application/json;application/xml


200 OK
Content-Type: application/json 



> Caching is making a copy of something to bring it closer at hand.


Resources have a finite set of operations (Methods) that they can be manipulated with.

GET - retreive a representation of this resource
POST - append this to the collection, or submit this entity for processing
PUT - replace the entity at this url with this new entity
DELETE - delete it. Make it no longer exposed on your API.

* OPTIONS


WE say there are different KINDS of resources.

Documents
- A singular thing. Like a singular employee, product, vehicle, etc.
Collections
- Groups of related resources

/employees/bob-smith - document

/employees - collection

// "Subordinate Resources"
GET /employees/bob-smith/manager 

200 Ok
{
    id: "sue-jones",
    firstName: "Sue",
    lastName: "Jones
}

GET /employees/sue-jones


GET /employees?manage="bob-smith"