import {HasId} from "../../domain/utility-types/HasId";

export function isHasId(payload: object): payload is HasId {
    if(!("id" in payload))
        return false;
    const idType = typeof (payload as {id: unknown}).id;
    return idType === "string" || idType === "number";
}