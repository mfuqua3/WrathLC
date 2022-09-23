import * as yup from "yup";

export const GetWishlistOptionsValidationSchema = yup.object().shape({
    filter: yup.string().required("Please specify search criteria").min(2, "At least two characters must be provided to search"),
    characterId: yup.number().required("A character must be specified").min(1, "A character must be specified"),
    page: yup.number().notRequired().min(0),
    pageSize: yup.number().notRequired().min(1)
});