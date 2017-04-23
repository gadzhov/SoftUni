select v.Name as 'VillainName', m.Name as 'MinionName', m.Age as 'MinionAge' from Villains as v
left join MinionsServeToVillains as mstv
on mstv.VillainsId = v.Id
left join Minions as m
on m.Id = mstv.MinionId
where v.Id = @id
group by v.Name, m.Name, m.Age