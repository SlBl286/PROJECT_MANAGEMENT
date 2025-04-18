import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import {  Issues } from "../types";
type UseGetIssuesProps = {
  me : boolean
}
export const useGetIssues= ({me}: UseGetIssuesProps) => {
  const query = useQuery({
    queryKey: ["issues",me],
    queryFn: async () => {
      try {
        const respone = await api.get<Issues>("/issues",{params: {me}})
        if (respone.statusText !== "OK") {
          return null;
      }
        const data = respone.data
        return data;
      } catch (error) {
        return null;
      }
    },
  });

  return query;
};
