# SegmentDotNet

Segment integration for your .NET Core projects, relies on dependency injection.

# Tests

Copy test/SegmentDotNet.Tests/sample.env to test/SegmentDotNet.Tests/.env and fill out the `SEGMENT_WRITE_KEY` variable with your Segment write key.

To run tests run `dotnet test` from the command line using test/SegmentDotNet.tests as your working directory.

There would be more tests but [Segment returns 200 response codes](https://segment.com/docs/libraries/http/#selecting-integrations) regardless of invalid input, auth keys, or any other bad information other than malformed/too large JSON. I'll add more once Segment fixes this.

Running tests will attempt to push events using the key defined as the environment variable `SEGMENT_WRITE_KEY`, you can check for results in the debugger on Segment for now.