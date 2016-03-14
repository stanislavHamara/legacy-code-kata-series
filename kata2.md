# Legacy Code Kata 2

Refer to the [readme.md](README.md) for an overview of the kata series and the code base we're working on.

## Learning aims

Practice techniques for writing decent quality tests against legacy code. Keep your tests DRY through relentless refactoring - this will help you produce high quality tests, which aren't poor quality like the production code that they cover.

## Tasks

Provide complete code coverage over the app. You could use NCrunch/DotCover to measure this.

1. Write a Golden Master test to capture the current behaviour of the whole app.

2. Write characterisation tests to capture the remaining behaviour of lower level and edge case parts of the system, e.g. per feature.

## Resources

### What is a Golden Master test?

A Golden Master test captures the output of the system. This lets you compare future output of the system against the saved “golden master” to discover unexpected changes.

See http://blog.codeclimate.com/blog/2014/02/20/gold-master-testing/
