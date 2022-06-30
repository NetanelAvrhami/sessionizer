# sessionizer

Space and time complexity

1.merge csv files - O(n+m+k) time and O(n+m+k) space, where m, n, o are the lengths of the firstCsv, secondCsv, and thirdCsv. (merge 3 sorted listed)

2.build users unique sites data stracture - O(n) time - running over the merged csv's list and map for each user his visited sites (dictionary 
with "userId" key and Set of site urls")

3.build sessions data stracture - O(n) time - running over the merged csv's list and mapp for each site list of sessions length which calculated
with dictionary that save the last session according to userId and siteUrl key. 

***All of the above operations are performed only once the server is up***

incoming request : 

- "api/sessions/total/${siteUrl}" - get number of sessions - O(1) time - get from sessions dictionary the size of the sessions list according to "site url" key.

- "api/sessiongs/median/${siteUrl}" - get median session length - O(nlogn) time - sorting the sessions durations list and returning the median.

- "api/users/numOfSites/${userId}" - get user unique sites - O(1) time - get from the users dictionary the size of the urls set according to "userId" key.

