select v.Name, count(mstv.MinionId) as 'Count' from Villains as v
inner join MinionsServeToVillains as mstv
on mstv.VillainsId = v.Id
group by v.Name
order by Count desc