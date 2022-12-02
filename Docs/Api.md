# TShop API

- [Category API](#category)
    - [Get category](#get-category)
    - [Create category](#create-category)
    - [Update category](#update-category)
    - [Delete category](#delete-category)
- [Product API](#product)

## Category

### Get category

#### Request
```js
GET /api/category
```

#### Response
```js
200 OK
```

```json
[
    {
        "id": "00000000-0000-0000-0000-000000000000",
        "name": "Category 1"
    },
    {
        "id": "00000000-0000-0000-0000-000000000000",
        "name": "Category 2"
    }
]
```

### Create category

#### Request
```js
POST /api/category
```

```json
{
    "name": "Category",
}
```
#### Response
```js
201 Created
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Category",
}
```

### Update category

#### Request
```js
PUT /api/category
```

```json
{
    "name": "Category",
}
```

#### Response
```js
204 No Content
```

### Delete category

#### Request
```js
DELETE /api/category/{:id}
```

#### Response
```js
204 No Content
```

## Product