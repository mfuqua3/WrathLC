export interface DiscordServer {
    id: number;
    name: string;
    guildId: number | null
}

export type DiscordServerItem = Omit<DiscordServer, "guildId">