export interface ITestResponse {
  testDetails: ITest
  statusCode: number,
  statusDescription: string
}

export interface ITest {
  id: string,
  description: string,
  questionViewModels: Array<IQuestion>
}

export interface IQuestion {
  questionId: string,
  questionText: string,
  answerViewModels: Array<IAnswer>
}

export interface IAnswer {
  answerId: string,
  answerText: string
  markAnswer: boolean
}
