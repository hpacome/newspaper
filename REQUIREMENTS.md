# requirements documents

## Introduction

This is the documentation for the implementation of a simple application that primarly create a database schema with a robust security checks.
Additionally, it will implement C# .net unit to validate the requirement.

## Use case 1 :
As a database administrator, I want to create a table named t_author with the following properties:

1. id: A universally unique identifier (UUID) that cannot be null and serves as the primary key of the table.
2. name: A string property with a maximum length of 255 characters, which cannot be null.
3. email: A string property with a maximum length of 255 characters, which cannot be null.

Additionally, I want to ensure that:
- The id property is set as the primary key of the table.
- The id property cannot be an empty UUID.

This table will allow us to store information about authors, including their name and email address, while ensuring data integrity and uniqueness.