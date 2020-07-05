export interface ITestResultResponse {
  testDetailResults: ITestResult
  statusCode: number,
  statusDescription: string
}

export interface ITestResult {
  id: string,
  description: string,
  questionResultViewModels: Array<IQuestionResult>
}

export interface IQuestionResult {
  questionId: string,
  questionText: string,
  markOn: Date,
  answerResultViewModels: Array<IAnswerResult>
}

export interface IAnswerResult {
  answerId: string,
  answerText: string,
  correctAnswer: boolean,
  markAnswer: boolean
}
