# sessionizer

Space and time complexity

1.merge csv files - O(n+m+k) time and O(n+m+k) space, where m, n, k are the lengths of the firstCsv, secondCsv, and thirdCsv. (merge 3 sorted listed)

2.build users unique sites data structure - O(n) time - running over the merged csv's list and map for each user his visited sites (dictionary 
with "userId" key and Set of site urls")

3.build sessions data structure - O(n) time - running over the merged csv's list and map for each site list of sessions length which calculated
with dictionary that save the last session according to userId and siteUrl key. 

***All the above operations are preformed statically once the server is up***

supporrted Apis : 

- "api/sessions/total/${siteUrl}" - get number of sessions - O(1) time - get from sessions dictionary the size of the sessions list according to "site url" key.

- "api/sessiongs/median/${siteUrl}" - get median session length - O(nlogn) time - sorting the sessions durations list and returning the median.

- "api/users/numOfSites/${userId}" - get user unique sites - O(1) time - get from the users dictionary the size of the urls set according to "userId" key.

Scaling: 

*Caching and Preprocessing for commonly used results. 

*Instead of 4 separate iterations - convert the csv,  merge the csvs, calcute sessions, calculate users site,
it can be rewriten to compute the sessions and users visited site in a one single pass.

*Save the sessions and users data on cloud db.

Testing:

My main goal was to write unit tests but I did not have time for it,
so I created 3 CSV files with small information and on them and I checked on them with debug mode.
