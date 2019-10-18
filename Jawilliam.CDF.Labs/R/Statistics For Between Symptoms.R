library(readr)

BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs30 - copia.txt", ";", escape_double = FALSE, trim_ws = TRUE)

#projects <- unique(BetweenSymptomsStats$Project)
#projects <- data.frame(projects)
#names(projects)[1] <- colnames(BetweenSymptomsStats)[1]

#approaches <- data.frame(approach=factor(), a28_Bp=double(), m28_Bp=double(), 
#                                               a29_BW=double(), m29_BW=double(), 
#                                               a30_BpIt=double(), m30_BpIt=double(),
#                                               a31_BW=double(), m31_BW=double(),
#                                               a32_It=double(), m32_It=double(),
#                                               a33_BW=double(), m33_BW=double(),
#                                               a34_BpDe=double(), m34_BpDe=double(),
#                                               a35_BW=double(), m35_BW=double(),
#                                               a36_BpDeIt=double(), m36_BpDeIt=double(),
#                                               a37_BW=double(), m37_BW=double() )
View(approaches)

#stats <- data.frame(BetweenSymptomsStats2_copia$Project, BetweenSymptomsStats2_copia$PrincipalRevisionPair)
#stats30Vs31 <- BetweenSymptomsStats2_copia[(BetweenSymptomsStats2_copia$`#lr_matches_31` != BetweenSymptomsStats2_copia$`#rl_matches_31`) | 
#                                           (BetweenSymptomsStats2_copia$`#lr_actions_31` != BetweenSymptomsStats2_copia$`#rl_actions_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_inserts_31` != BetweenSymptomsStats2_copia$`#rl_deletes_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_deletes_31` != BetweenSymptomsStats2_copia$`#rl_inserts_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_updates_31` != BetweenSymptomsStats2_copia$`#rl_updates_31`) |
#                                           (BetweenSymptomsStats2_copia$`#lr_moves_31` != BetweenSymptomsStats2_copia$`#rl_moves_31`),]

BetweenSymptomsStats <- read_delim("D:/ExperimentLogs/BetweenSymptomsStats_28Vs30.txt", ";", escape_double = FALSE, trim_ws = TRUE)

stats <- data.frame(Left_Best_Actions=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] < BetweenSymptomsStats[22]),]), 
                    Right_Best_Actions=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] > BetweenSymptomsStats[22]),]), 
                    Equal_Actions=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] == BetweenSymptomsStats[22]),]),
                    NotEqual_Actions=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),]),
                    ALL_Mismatches=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[27] != 0),]), 
                    LR_Mismatches=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[28] != 0),]), 
                    RL_Mismatches=nrow(BetweenSymptomsStats[which(BetweenSymptomsStats[29] != 0),]))
View(stats)

View(BetweenSymptomsStats[which(BetweenSymptomsStats[16] != BetweenSymptomsStats[22]),])
#for (i in 1:nrow(stats)) 
#{
#  stats[i,1]
#}
