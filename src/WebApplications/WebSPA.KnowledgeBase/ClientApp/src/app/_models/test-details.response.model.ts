export interface ITestDetailsResponse {
  testDetails: ITestDetails
  statusCode: number,
  statusDescription: string
}

export interface ITestDetails {
  id: string,
  description: string,
  questionViewModels: Array<IQuestionDetails>
}

export interface IQuestionDetails {
  questionId: string,
  questionText: string,
  answerViewModels: Array<IAnswerDetails>
}

export interface IAnswerDetails {
  answerId: string,
  answerText: string
  markAnswer: boolean
}
