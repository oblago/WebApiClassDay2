# Courses API

## Resources


### GET /courses

```json

{
    "numerOfCouses": 1,
    "data": [
        {"id": "1", "title": "Web APIs"},
    ]
}
```
### GET /courses/{id}

```json

{
    "id": "1",
    "title": "Web APIs",
    "numberOfHours": 27.5,
    "deliveryLocation": "Online"

}