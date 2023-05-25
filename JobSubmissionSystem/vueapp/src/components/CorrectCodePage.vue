<template>
    <el-aside id="treeView">
        <el-tree v-show="treeView" :data="treeView" :props="treeProps" @node-click="FileTreeClick">

        </el-tree>
    </el-aside>
    <el-main style="height: 70%;">
        <el-card class="box-card">
            <template #header>
                <div class="card-header">
                    <span>{{filename}}</span>
                    <el-button class="button" text>Operation button</el-button>
                </div>
            </template>
            <el-scrollbar>
                <el-text id="code">
                    <el-text v-for="(data,index) in code_data" @mouseup.stop="process($event,index)">
                        <el-text v-if="!data.flagged" color="red">
                            {{data.code}}
                        </el-text>
                        <el-text type="danger" v-else="data.flagged">
                            {{data.code}}
                        </el-text>
                    </el-text>
                </el-text>
            </el-scrollbar>
            
        </el-card>
    </el-main>
</template>

<script>
    import axios from '../../api/config'
    export default {
        name: "CodePage",

        data() {
            return {
                treeView: null,
                treeProps: {
                    children: 'sonNodes',
                    label: 'filename'
                },
                code_data: [
                    {
                        code: "禁用页面的拖拽方法，防止文字选中功能被覆盖",
                        flagged: false
                    },
                    
                ],
                orgin_code:"",
                filename: null
            }
        },
        mounted() {
            //禁用页面的拖拽方法，防止文字选中功能被覆盖
            window.addEventListener("dragstart", (e) => {
                e.preventDefault();
                e.stopPropagation(); 
            }); 
        },

        methods: {
            FileTreeClick(data) {
                this.code_data = [
                    {
                        code: data.fileInformation.code,
                        flagged: false,
                    }
                ];
                this.orgin_code = data.fileInformation.code;
                this.filename = data.filename;
            },
            process(event,index) {
                if (!window.getSelection().toString()) {
                    return
                }
                //阻止事件冒泡
                //不仅仅要stopPropagation，还要preventDefault
                function pauseEvent(e) {
                    if (e.stopPropagation) e.stopPropagation();
                    if (e.preventDefault) e.preventDefault();
                    e.cancelBubble = true;
                    e.returnValue = false;
                    return false;
                }
                var start_pos = window.getSelection().anchorOffset;
                var end_pos = window.getSelection().focusOffset;
                var code_slice = this.code_data[index].code;
                if (!code_slice.includes(window.getSelection().toString())) {
                    return
                }
                var str1 = code_slice.substring(0, start_pos)
                var str2 = code_slice.substring(start_pos, end_pos)
                var str3 = code_slice.substring(end_pos, code_slice.length)
                console.log(str1 + "\n")
                console.log(str2 + "\n")
                console.log(str3 + "\n")
                this.code_data.splice(index, 1, { code: str1, flagged: false }, { code: str2, flagged: true }, {code:str3,flagged:false})
                pauseEvent(event);
                console.log(start_pos,end_pos)
                //console.log(this.orgin_code.substr(start_pos,end_pos));
                    
            }
        },
        created() {
            //console.log(this.treeView)
            axios.get('api/CorrectionInfor').then(
                response => (this.treeView = [response.data.treeView])
            )
            console.log(this.treeView)
        }
    };
</script>

<style>
    #treeView {
        width: 250px;
        float: Left;
    }

    #code {
        white-space: pre;
        height: 65vh;
        width: 100%;
        outline: none;
        min-width: 600px;
    }
    .card-header{
        height:5vh;
    }
    .box-card {
        height: 80vh;
    }
</style>