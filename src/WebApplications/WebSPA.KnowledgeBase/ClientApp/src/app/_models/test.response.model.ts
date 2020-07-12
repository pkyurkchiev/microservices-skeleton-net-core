export interface ITestResponse {
  tests: Array<ITest>
  statusCode: number,
  statusDescription: string
}

export interface ITest {
  id: string,
  description: string,
  status: string,
  finishedOn: string  
}
