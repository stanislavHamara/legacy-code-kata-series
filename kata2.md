# Legacy Code Kata 2

Refer to the [readme.md](README.md) for an overview of the kata series and the code base we're working on.

## Learning aims

Practice techniques for writing decent quality tests against legacy code. Keep your tests DRY through relentless refactoring - this will help you produce high quality tests, which aren't poor quality like the production code that they cover.

## Tasks

Provide complete code coverage over the app. You could use NCrunch/DotCover to measure this.

1. **Write a Golden Master test** to capture the current behaviour of the whole app.

2. **Write characterisation tests** to capture the remaining behaviour of lower level and edge case parts of the system, e.g. per feature.

## FAQ

### What is a Golden Master test?

A Golden Master test captures the output of the entire system. This lets you compare future output of the system against the saved “golden master” to discover unexpected changes.

See http://blog.codeclimate.com/blog/2014/02/20/gold-master-testing/

### What is a characterisation test?

Characterisation tests describe the actual behavior of an existing piece of software. They protect the existing behavior of legacy code against unintended changes via automated testing. They provide a safety net for extending and refactoring code that does not have adequate unit tests.

See https://en.wikipedia.org/wiki/Characterization_test
