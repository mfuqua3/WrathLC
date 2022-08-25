import { ApiErrorModel } from "../../domain/models";

export function isApiError(candidate: object): candidate is ApiErrorModel {
    return "status" in candidate && "statusCode" in candidate && "message" in candidate;
}
