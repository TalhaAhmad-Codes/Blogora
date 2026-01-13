
---

# User Reaction - DTOs Schemas

---

## Get / Create

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **userId** | int | `No` |
| **blogId** | int | `No` |
| **reactionType** | int | `No` |

---

## Filter

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **userId** | int | `Yes` |
| **blogId** | int | `Yes` |
| **reactionType** | int | `Yes` |

---

## Update Reaction Type

| Placeholder | Data Type | Nullable |
|-------------|-----------|----------|
| **reactionType** | int | `No` |

---

### Reaction Type - Handling

> **Note:** Backend handles reaction type as an enum, so client needs to pass a value based on the following table.

| Reaction Type | Value |
|---------------|-------|
| Like | 1 |
| Dislike | 2 |

---
