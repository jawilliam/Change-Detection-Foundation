library(readr)

BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs30 - copia.txt", ";", escape_double = FALSE, trim_ws = TRUE)

projects <- unique(BetweenSymptomsStats$Project)
projects <- data.frame(projects)
names(projects)[1] <- colnames(BetweenSymptomsStats)[1]

#stats <- data.frame(BetweenSymptomsStats2_copia$Project, BetweenSymptomsStats2_copia$PrincipalRevisionPair)
#stats30Vs31 <- BetweenSymptomsStats2_copia[(BetweenSymptomsStats2_copia$`#lr_matches_31` != BetweenSymptomsStats2_copia$`#rl_matches_31`) | 
#                                           (BetweenSymptomsStats2_copia$`#lr_actions_31` != BetweenSymptomsStats2_copia$`#rl_actions_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_inserts_31` != BetweenSymptomsStats2_copia$`#rl_deletes_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_deletes_31` != BetweenSymptomsStats2_copia$`#rl_inserts_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_updates_31` != BetweenSymptomsStats2_copia$`#rl_updates_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_moves_31` != BetweenSymptomsStats2_copia$`#rl_moves_31`),]

allmismatches <- BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),]
View(allmismatches)
allmisactions <- BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),]
View(allmisactions)

lBest <- BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),]
print("Left Best: ")
nrow(lBest)
rBest <- BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),]
print("Right Best")
nrow(rBest)
noBest <- BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),]
print("No Best")
nrow(noBest)

#for (i in 1:nrow(stats)) 
#{
#  stats[i,1]
#}
