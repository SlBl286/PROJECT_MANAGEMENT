
import z from "zod";

export const uploadSchema = z.object({
    file: z.instanceof(File)
});

export const removeSchema = z.object({
    fileName: z.string()
});
