library(readr)

projects <- unique(BetweenSymptomsStats2_copia$Project)
projects <- data.frame(projects)
names(projects)[1] <- colnames(BetweenSymptomsStats2_copia)[1]

#stats <- data.frame(BetweenSymptomsStats2_copia$Project, BetweenSymptomsStats2_copia$PrincipalRevisionPair)
#stats30Vs31 <- BetweenSymptomsStats2_copia[(BetweenSymptomsStats2_copia$`#lr_matches_31` != BetweenSymptomsStats2_copia$`#rl_matches_31`) | 
#                                           (BetweenSymptomsStats2_copia$`#lr_actions_31` != BetweenSymptomsStats2_copia$`#rl_actions_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_inserts_31` != BetweenSymptomsStats2_copia$`#rl_deletes_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_deletes_31` != BetweenSymptomsStats2_copia$`#rl_inserts_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_updates_31` != BetweenSymptomsStats2_copia$`#rl_updates_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_moves_31` != BetweenSymptomsStats2_copia$`#rl_moves_31`),]

stats30Vs31 <- BetweenSymptomsStats2_copia[which(BetweenSymptomsStats2_copia$`#all_mismatches_30Vs31` != 0),]
stats30Vs32 <- BetweenSymptomsStats2_copia[which(BetweenSymptomsStats2_copia$`#all_mismatches_30Vs32` != 0),]
stats30Vs28 <- BetweenSymptomsStats2_copia[which(BetweenSymptomsStats2_copia$`#all_mismatches_30Vs28` != 0),]

for (i in 1:nrow(stats)) 
{
  stats[i,1]
}
