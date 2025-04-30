# LabbAPI


---

## Översikt
| Metod | Endpoint                                         | Beskrivning                                      |
|-------|--------------------------------------------------|--------------------------------------------------|
| GET   | `/api/person`                                    | Hämtar alla personer                             |
| GET   | `/api/person/{id}`                               | Hämtar intressen för en person                   |
| GET   | `/api/person/{personId}/link`                    | Hämtar alla URL:er kopplade till en persons intressen |
| POST  | `/api/person/{personId}/add-interest`            | Lägg till ett nytt intresse till en person      |
| POST  | `/api/person/{personId}/interests/{interestId}/add-link` | Lägg till en URL till ett persons intresse |

---
<details close>
<summary>Hämta alla personer</summary>
<br>
  
````
[GET] /api/person
````
**Request URL**
````
https://localhost:7072/api/Person
````
**Request**
````
{
  "id": 0,
  "firstName": "string",
  "lastName": "string",
  "telefonnummer": "string",
  "email": "string"
}
````
**Beskrivning**
````
Hämtar alla personer som ligger i databasen.
````

**Exempel Response:**
````
[
  {
    "id": 1,
    "firstName": "Kim",
    "lastName": "Andersson",
    "telefonnummer": "0701234560",
    "email": "kim@example.com"
  }
]
````
</details>

<details close>
<summary>Hämtar intressen för en person</summary>
<br>
  
````
[GET] /api/person/{personId}/Interest
````
**Request URL**
````
https://localhost:7072/api/Person/{personId}/Interest
````
**Request**
````
{
  "firstName": "string",
  "lastName": "string",
  "interests": [
    {
      "id": int,
      "title": "string",
      "description": "string",
      "url": [
        "string"
      ]
    }
  ]
}
````
**Beskrivning**
````
Hämtar intressen för en person genom att ange personens ID.
````

**Exempel Response:**
````
{
      "id": 12,
      "title": "ölhävning",
      "description": "Dricker mängder med öl",
      "url": [
        "https://www.bordershop.com/se"
      ]
    }
````
</details>

<details close>
<summary>Hämta en person's länkar</summary>
<br>
  
````
[GET] /api/person/{personId}/Link
````
**Request URL**
````
https://localhost:7072/api/Person/{personId}/Link
````
**Request**
````
[
  {
    "url": "string"
  }
}
````
**Beskrivning**
````
Hämtar alla länkar som är kopplade till en person's intressen.
````

**Exempel Response:**
````
[
  {
    "url": "www.test.com"
  }
}
````

</details>

<details close>
<summary>Lägg till ett nytt intresse</summary>
<br>
  
````
[POST] /api/person/{personId}/idd-interest
````
**Request URL**
````
https://localhost:7072/api/Person/{personId}/add-interest
````
**Request**
````
{
  "title": "string",
  "description": "string"
}
````
**Beskrivning**
````
Kopplar ett nytt intresse till en person.
````

**Exempel Response:**
````
{
  "id": 16,
  "personId": 1,
  "person": {
    "id": 1,
    "firstName": "Kim",
    "lastName": "Andersson",
    "telefonnummer": "0701234560",
    "email": "kim@example.com",
    "personInterests": [
      null
    ]
  },
  "interestId": 11,
  "interest": {
    "id": 11,
    "title": "biljakt",
    "description": "Stannar inte för någon",
    "personInterests": [
      null
    ]
  },
  "link": null
}

````
</details>

<details close>
<summary>Lägg till en URL</summary>
<br>
  
````
[POST] /api/Person/{personId}/interests/{InterestId}/add-link
````
**Request URL**
````
https://localhost:7072//api/Person/{personId}/interests/{InterestId}/add-link
````
**Request**
````
{
  "url": "string"
}
````
**Beskrivning**
````
Lägger till en ny länk till ett intresse som är kopplat till en person.
````

**Exempel Response**
````
{
  "id": 21,
  "personInterestId": 7,
  "personInterest": {
    "id": 7,
    "personId": 5,
    "person": {
      "id": 5,
      "firstName": "Max",
      "lastName": "Bengtsson",
      "telefonnummer": "0701234564",
      "email": "max@example.com",
      "personInterests": [
        null
      ]
    },
    "interestId": 2,
    "interest": null,
    "link": [
      null
    ]
  },
  "url": "www.fz.com"
}
````
</details>
