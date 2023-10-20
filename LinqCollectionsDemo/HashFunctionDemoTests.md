The `HashFunctionDemoTests` class contains unit tests to demonstrate the behavior of a custom hash function and its associated insertion and retrieval operations on a hash table. Three tests are defined:

1. **InsertAndRetrieveTest**: Tests basic insertion and retrieval of values in the hash table, asserting that the inserted values can be correctly retrieved.
2. **CollisionTest**: Demonstrates a collision scenario where two different strings that hash to the same value are inserted, and verifies that the latter string overwrites the former.
3. **EmptySpaceTest**: Inserts a single string and checks all positions in the hash table, verifying that only the hashed position is filled, while all other positions remain null.

Before each test, the `SetUp` method initializes the hash table to a predefined size. This setup ensures a clean state for each test, facilitating isolated and repeatable testing conditions.