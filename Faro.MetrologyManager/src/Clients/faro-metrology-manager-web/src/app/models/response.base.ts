import { ExecutionStatus } from './execution.status';
import { ResponseMessage } from './response.message';

export interface ResponseBase<T> {
  executionResponseStatus?: ExecutionStatus;
  readonly executionResponseStatusDescription?: string;
  data?: T;
  responseMessageCollection?: Array<ResponseMessage>;
}
