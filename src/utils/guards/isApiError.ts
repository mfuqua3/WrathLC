import {ApiError} from "../../domain/models";

export function isApiError(candidate: object): candidate is ApiError {
    return "status" in candidate && "statusCode" in candidate && "message" in candidate;
}
